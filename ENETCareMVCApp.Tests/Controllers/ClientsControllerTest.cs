﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ENETCareMVCApp.Controllers;
using ENETCareMVCApp.Models;
using ENETCareMVCApp.Repositories;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ENETCareMVCApp.Tests.Controllers
{
    [TestClass]
    public class ClientsControllerTest
    {
        Client formData = new Client
        {
            ClientID = 100,
            ClientName = "Tom",
            Address = "Whatever",
            DistrictID = 1,
        };

        [TestMethod]
        public void CreateClient_PostOk()
        {
            Mock<IClientRepository> service = new Mock<IClientRepository>();
            service.Setup(x => x.AddClients(It.IsAny<Client>())).Returns<Client>(e => { e.ClientID = 100; return e; });
            var controller = new ClientsController(service.Object);
            
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(formData);
            Assert.AreEqual(100, result.RouteValues["id"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
