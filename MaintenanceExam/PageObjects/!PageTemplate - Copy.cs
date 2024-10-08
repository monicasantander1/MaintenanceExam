﻿using OpenQA.Selenium;

namespace MaintenanceExam.PageObjects
{
    public class PageTemplate : BasePageLocal
    {
        private readonly By _sampleLocator = By.Id("sampleId");

        public PageTemplate(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// This is a sample method
        /// </summary>
        public void SampleMethod()
        {
            Click(_sampleLocator);
        }
    }
}