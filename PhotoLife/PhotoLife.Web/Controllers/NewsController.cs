﻿using System;
using System.Web.Mvc;
using CloudinaryDotNet;
using PhotoLife.Authentication.Providers;
using PhotoLife.Factories;
using PhotoLife.Services.Contracts;
using PhotoLife.ViewModels.News;

namespace PhotoLife.Controllers
{
    public class NewsController : Controller
    {
        private readonly IAuthenticationProvider authenticationProvider;
        private readonly INewsService newsService;
        private readonly IViewModelFactory viewModelFactory;

        private readonly Cloudinary cloudinary;

        public NewsController(
            IAuthenticationProvider authenticationProvider,
            INewsService newsService,
            IViewModelFactory viewModelFactory,
            Cloudinary cloudinary)
        {
            if (authenticationProvider == null)
            {
                throw new ArgumentNullException(nameof(authenticationProvider));
            }

            if (newsService == null)
            {
                throw new ArgumentNullException(nameof(newsService));
            }

            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }

            if (cloudinary == null)
            {
                throw new ArgumentNullException(nameof(cloudinary));
            }

            this.authenticationProvider = authenticationProvider;
            this.newsService = newsService;
            this.viewModelFactory = viewModelFactory;

            this.cloudinary = cloudinary;
        }
        // Get: All
        public ActionResult All()
        {
            return View();
        }

        // [Authorize(Roles = "Administrators")]
        public ActionResult Add()
        {
            return View(this.viewModelFactory.CreateAddNewsViewModel(this.cloudinary));
        }

        // Post: News
        //[Authorize(Roles = "Administrators")]
        [HttpPost]
        public ActionResult Add(AddNewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.authenticationProvider.CurrentUserId;

                var news = this.newsService.CreateNews(userId, model.Title, model.Text, model.CoverPicture, model.Category);


                return RedirectToAction("NewsDetails", "News", new { newsId = news.NewsId});
            }

            model.Cloudinary = this.cloudinary;
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult NewsDetails(int newsId)
        {
            var news = this.newsService.GetNewsById(newsId);

            var newsModel = this.viewModelFactory.CreateNewsDetailsViewModel(news);

            return View(newsModel);
        }
    }
}