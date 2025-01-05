//using System.Net.Http;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using AddItemApp;
//using Microsoft.AspNetCore.Hosting;

//namespace AddItemApp.Tests
//{
//    [TestClass]
//    public class ItemControllerTests
//    {
//        private readonly WebApplicationFactory<Startup> _factory;
//        private readonly HttpClient _client;

//        public ItemControllerTests()
//        {
//            _factory = new WebApplicationFactory<Startup>();
//            _client = _factory.CreateClient();
//        }

//        [TestMethod]
//        public async Task Index_ReturnsSuccessStatusCode()
//        {
//            var response = await _client.GetAsync("/Item/Index");

//            response.EnsureSuccessStatusCode();
//            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
//        }

//        [TestMethod]
//        public async Task Create_ReturnsSuccessStatusCode()
//        {
//            var response = await _client.GetAsync("/Item/Create");

//            response.EnsureSuccessStatusCode();
//            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
//        }

//        [TestMethod]
//        public async Task Create_Post_ReturnsRedirect()
//        {
//            var newItem = new FormUrlEncodedContent(new[]
//            {
//                new KeyValuePair<string, string>("Name", "Test Item"),
//                new KeyValuePair<string, string>("Description", "This is a test item."),
//                new KeyValuePair<string, string>("ImageUrl", "https://www.propartnergroup.com/resources/how-to-set-up-a-travel-agency-in-the-uae-pro-partner-group.jpg")
//            });

//            var response = await _client.PostAsync("/Item/Create", newItem);

//            Assert.IsTrue(response.IsSuccessStatusCode);
//            Assert.AreEqual("/Item/Index", response.Headers.Location.AbsolutePath); // Ensure the redirect goes to Index
//        }

//        [TestMethod]
//        public async Task Edit_ReturnsSuccessStatusCode()
//        {
//            var response = await _client.GetAsync("/Item/Edit/1");

//            response.EnsureSuccessStatusCode();
//            Assert.AreEqual("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
//        }

//        [TestMethod]
//        public async Task Edit_Post_ReturnsRedirect()
//        {
//            var updatedItem = new FormUrlEncodedContent(new[]
//            {
//                new KeyValuePair<string, string>("Id", "1"),
//                new KeyValuePair<string, string>("Name", "Updated Test Item"),
//                new KeyValuePair<string, string>("Description", "This item has been updated."),
//                new KeyValuePair<string, string>("ImageUrl", "http://test.com/updated-image.jpg")
//            });

//            var response = await _client.PostAsync("/Item/Edit/1", updatedItem);

//            Assert.IsTrue(response.IsSuccessStatusCode);
//            Assert.AreEqual("/Item/Index", response.Headers.Location.AbsolutePath); // Ensure the redirect goes to Index
//        }

//        [TestMethod]
//        public async Task Delete_ReturnsSuccessStatusCode()
//        {
//            var response = await _client.PostAsync("/Item/Delete/1", null);

//            response.EnsureSuccessStatusCode();
//            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
//        }
//    }
//}
