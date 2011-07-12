using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using TDDBlog.Models;
using TDDBlog.Controllers;

namespace TDDBlog.Tests.Controllers
{
    [TestFixture]
    public class BlogControllerTest
    {
        [Test]
        public void IndexReturnsAListOfBlogEntriesWithCorrectUrls()
        {
            
            var mockBlogEntry1 = new Mock<BlogEntry>();

            const int id1 = 1;
            const string title1 = "My first blog Entry";
            const string content1 = "I love blogging, it is so cool";

            mockBlogEntry1.SetupGet(x => x.Id).Returns(id1);
            mockBlogEntry1.SetupGet(x => x.Title).Returns(title1);
            mockBlogEntry1.SetupGet(x => x.Content).Returns(content1);

            const int id2 = 2;
            const string title2 = "I'm still in to this";
            const string content2 = "I'm still enjoying my blogging";

            var mockBlogEntry2 = new Mock<BlogEntry>();

            mockBlogEntry2.SetupGet(x => x.Id).Returns(id2);
            mockBlogEntry2.SetupGet(x => x.Title).Returns(title2);
            mockBlogEntry2.SetupGet(x => x.Content).Returns(content2);

            const int id3 = 3;
            const string title3 = "OK!";
            const string content3 = "Ok, I'm done!";

            var mockBlogEntry3 = new Mock<BlogEntry>();

            mockBlogEntry3.SetupGet(x => x.Id).Returns(id3);
            mockBlogEntry3.SetupGet(x => x.Title).Returns(title3);
            mockBlogEntry3.SetupGet(x => x.Content).Returns(content3);

            var blogRepository = new Mock<IBlogsRepository>();

            blogRepository
                .Setup(p => p.GetAllBlogEntries())
                .Returns(new List<BlogEntry> { mockBlogEntry1.Object, mockBlogEntry2.Object, mockBlogEntry3.Object });

            BlogController blogController = new BlogController((IBlogsRepository)blogRepository.Object);

            ViewResult viewResult = blogController.Index() as ViewResult;

            List<BlogEntry> blogEntries = (System.Collections.Generic.List<BlogEntry>)viewResult.ViewData.Model;
            BlogEntry blogEntry1 = blogEntries[0];

            Assert.AreEqual(id1, blogEntry1.Id);
            Assert.AreEqual(title1, blogEntry1.Title);
            const string url1 = "my-first-blog-entry";
            Assert.AreEqual(url1, blogEntry1.Url);
            Assert.AreEqual(content1, blogEntry1.Content);

            BlogEntry blogEntry2 = blogEntries[1];

            Assert.AreEqual(id2, blogEntry2.Id);
            Assert.AreEqual(title2, blogEntry2.Title);
            const string url2 = "im-still-in-to-this";
            Assert.AreEqual(url2, blogEntry2.Url);
            Assert.AreEqual(content2, blogEntry2.Content);

            BlogEntry blogEntry3 = blogEntries[2];

            Assert.AreEqual(id3, blogEntry3.Id);
            Assert.AreEqual(title3, blogEntry3.Title);
            const string url3 = "ok";
            Assert.AreEqual(url3, blogEntry3.Url);
            Assert.AreEqual(content3, blogEntry3.Content);
        }
    }


}
