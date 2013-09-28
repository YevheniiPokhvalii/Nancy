﻿namespace Nancy.Testing.Tests.TestingViewExtensions
{
    using Xunit;

    public class GetViewNameExtensionTests
    {
        private readonly Browser _browser;

        public GetViewNameExtensionTests()
        {
            this._browser = new Browser(with =>
            {
                with.Module<TestingViewFactoryTestModule>();
                with.ViewFactory<TestingViewFactory>();
            });
        }

        [Fact]
        public void GetViewName_should_return_name_of_the_view_for_routes_with_view()
        {
            var response = this._browser.Get("/testingViewFactory");
            Assert.Equal("TestingViewExtensions/ViewFactoryTest.sshtml", response.GetViewName());
        }

        [Fact]
        public void GetViewName_should_return_empty_string_for_routes_withoutuu_view()
        {
            var response = this._browser.Get("/testingViewFactoryNoViewName", 
                with => with.Accept("application/json"));
            Assert.Equal(string.Empty, response.GetViewName());
        }

        
    }

    //    [Fact]
    //    public void should_set_the_module_name()
    //    {
    //        Assert.Equal("TestingViewFactoryTest", this._response.GetModuleName());
    //    }
}
