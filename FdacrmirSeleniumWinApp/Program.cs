using FdacrmirSeleniumWinApp.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace FdacrmirSeleniumWinApp
{
    class Program
    {
        static IWebDriver driver;
        static void Main(string[] args)
        {
            var _context = new fdacrm_DBContext();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@"user-data-dir=C:\Users\ym\AppData\Local\Google\Chrome\User Data\Default");
            options.AddArgument("--log-level=3");
            options.AddArguments("headless");

            driver = new ChromeDriver(options);

            var last = _context.TblLogs.AsNoTracking().FirstOrDefault();

            if (last != null)
            {
                Console.WriteLine($"Enter start ID, Last submitted ID is: {last.LastId-1}");
            }
            else
            {
                Console.WriteLine($"Enter start ID, Last submitted ID is: Empty");
            }

            string startIdstr = Console.ReadLine();
            int startid = 0;

            try
            {
                startid = int.Parse(startIdstr);
                if (startid == 0)
                {
                    Console.WriteLine("Wrong Input!!!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong Input!!!");
                Console.ReadLine();
                Environment.Exit(0);
            }



            for (int i = startid; i < 9999999; i++)
            {
                if (_context.TblLogs.Any())
                {
                    _context.TblLogs.FirstOrDefault().LastId = i;
                }
                else
                {
                    _context.TblLogs.Add(new TblLog { LastId = i });
                }
                _context.SaveChanges();

                var num = i + "";
                driver.Url = "http://www.fdacrm.ir/show.aspx?pavanenum=" + num.Insert(2, "/");

                var Detail = new TblDetail();

                var Product = new TblProduct();
                long productId = 0;

                var Brand = new TblBrand();
                long brandId = 0;

                var Pack = new TblPackingDetail();
                long packId = 0;

                var Factory = new TblFactoryName();
                long factoryId = 0;

                var Addrs = new TblAddress();
                long addressId = 0;

                var Phone = new TblTelephoneNumber();
                long phoneId = 0;

                if (IfElementExists(By.XPath("/html/body/span/h1")))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\rLast ID : {0} ", _context.TblLogs.FirstOrDefault().LastId);
                    continue;
                }
                else
                {
                    Detail.FldManufacturingLicenseNumber = driver.FindElement(By.Id("Label2")).Text;
                    Detail.Id = Int64.Parse(driver.FindElement(By.Id("Label2")).Text.Replace("/", ""));

                    var p = driver.FindElement(By.Id("Label4")).Text;
                    if (!_context.TblProducts.Where(a => a.FldProduct == p).Any())
                    {
                        Product.FldProduct = p;
                        _context.TblProducts.Add(Product);
                        _context.SaveChanges();
                        productId = Product.Id;
                    }
                    else
                    {
                        productId = _context.TblProducts.Where(a => a.FldProduct == p).FirstOrDefault().Id;
                    }
                    Detail.FldProductId = productId;


                    var b = driver.FindElement(By.Id("Label6")).Text;
                    if (!_context.TblBrands.Where(a => a.FldBrand == b).Any())
                    {
                        Brand.FldBrand = b;
                        _context.TblBrands.Add(Brand);
                        _context.SaveChanges();
                        brandId = Brand.Id;
                    }
                    else
                    {
                        brandId = _context.TblBrands.Where(a => a.FldBrand == b).FirstOrDefault().Id;
                    }
                    Detail.FldBrandId = brandId;



                    var pa = driver.FindElement(By.Id("Label20")).Text;
                    if (!_context.TblPackingDetails.Where(a => a.FldPackingDetails == pa).Any())
                    {
                        Pack.FldPackingDetails = pa;
                        _context.TblPackingDetails.Add(Pack);
                        _context.SaveChanges();
                        packId = Pack.Id;
                    }
                    else
                    {
                        packId = _context.TblPackingDetails.Where(a => a.FldPackingDetails == pa).FirstOrDefault().Id;
                    }
                    Detail.FldPackingDetailsId = packId;



                    var f = driver.FindElement(By.Id("Label8")).Text;
                    if (!_context.TblFactoryNames.Where(a => a.FldFactoryName == f).Any())
                    {
                        Factory.FldFactoryName = f;
                        _context.TblFactoryNames.Add(Factory);
                        _context.SaveChanges();
                        factoryId = Factory.Id;
                    }
                    else
                    {
                        factoryId = _context.TblFactoryNames.Where(a => a.FldFactoryName == f).FirstOrDefault().Id;
                    }
                    Detail.FldFactoryNameId = factoryId;



                    var a = driver.FindElement(By.Id("Label26")).Text;
                    if (!_context.TblAddresses.Where(x => x.FldAddress == a).Any())
                    {
                        Addrs.FldAddress = a;
                        _context.TblAddresses.Add(Addrs);
                        _context.SaveChanges();
                        addressId = Addrs.Id;
                    }
                    else
                    {
                        addressId = _context.TblAddresses.Where(x => x.FldAddress == a).FirstOrDefault().Id;
                    }
                    Detail.FldAddressId = addressId;




                    var t = driver.FindElement(By.Id("Label28")).Text;
                    if (!_context.TblTelephoneNumbers.Where(x => x.FldTelephone == t).Any())
                    {
                        Phone.FldTelephone = t;
                        _context.TblTelephoneNumbers.Add(Phone);
                        _context.SaveChanges();
                        phoneId = Phone.Id;
                    }
                    else
                    {
                        phoneId = _context.TblTelephoneNumbers.Where(x => x.FldTelephone == t).FirstOrDefault().Id;
                    }
                    Detail.FldTelephoneNumberId = phoneId;


                    Detail.FldIssueDate = driver.FindElement(By.Id("Label10")).Text;

                    Detail.FldExpireDate = driver.FindElement(By.Id("Label12")).Text;

                }

                if (!_context.TblDetails.Where(a => a.Id == Detail.Id).Any())
                {
                    _context.TblDetails.Add(Detail);
                    _context.SaveChanges();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rLast ID : {0} ", _context.TblLogs.FirstOrDefault().LastId);

            }

        }

        public static bool IfElementExists(By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            return true;
        }


    }
}
