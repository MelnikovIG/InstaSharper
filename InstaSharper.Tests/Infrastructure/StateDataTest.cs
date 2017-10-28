﻿using System;
using System.Collections.Generic;
using System.Text;
using InstaSharper.Classes;
using InstaSharper.Tests.Classes;
using InstaSharper.Tests.Utils;
using Xunit;

namespace InstaSharper.Tests.Infrastructure
{
    [Trait("Category", "Infrastructure")]
    public class StateDataTest : IClassFixture<AuthenticatedTestFixture>
    {
        public StateDataTest(AuthenticatedTestFixture authInfo)
        {
            _authInfo = authInfo;
        }

        private readonly AuthenticatedTestFixture _authInfo;

        [Fact]
        public async void GetSetStateDataTest()
        {
            Assert.True(_authInfo.ApiInstance.IsUserAuthenticated);

            var getUserResult = await _authInfo.ApiInstance.GetCurrentUserAsync();
            var user = getUserResult.Value;

            var data = _authInfo.ApiInstance.GetStateData();
            var newApiInstance = TestHelpers.GetDefaultInstaApiInstance(new UserSessionData());
            newApiInstance.SetStateData(data);
            var newGetUserResult = await _authInfo.ApiInstance.GetCurrentUserAsync();
            var newUser = getUserResult.Value;

            Assert.True(getUserResult.Succeeded && newGetUserResult.Succeeded);
            Assert.NotNull(user);
            Assert.NotNull(newUser);
            Assert.Equal(user.UserName, _authInfo.GetUsername());
            Assert.Equal(newUser.UserName, _authInfo.GetUsername());

        }
    }
}
