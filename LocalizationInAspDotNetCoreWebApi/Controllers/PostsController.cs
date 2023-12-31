﻿using LocalizationInAspDotNetCoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationInAspDotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IStringLocalizer<PostsController> stringLocalizer;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;

        public PostsController(IStringLocalizer<PostsController> postsControllerLocalizer, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            this.stringLocalizer = postsControllerLocalizer;
            this.sharedResourceLocalizer = sharedResourceLocalizer;
        }

        /// <summary>
        /// This endpoint will access the PostsController Resource to retrieve the localized data ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PostsControllerResource")]
        public IActionResult GetUsingPostsControllerResource()
        {
            var article = stringLocalizer["HiLamia"];
            var postName = stringLocalizer.GetString("WelcometoAspNetCore").Value ?? "";

            return Ok(new { PostType = article.Value, PostName = postName });
        }

        /// <summary>
        /// This endpoint will access the SharedResourece to retrieve the localized data ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SharedResource")]
        public IActionResult GetUsingSharedResource()
        {
            var article = sharedResourceLocalizer["HiLamia"];
            var postName = sharedResourceLocalizer.GetString("WelcometoAspNetCore").Value ?? "";

            return Ok(new { PostType = article.Value, PostName = postName });
        }
    }
}
