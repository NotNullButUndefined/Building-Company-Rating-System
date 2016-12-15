(function () {
    'use strict';

    angular
        .module('app')
        .factory('LoginFactory', LoginFactory);

    LoginFactory.$inject = ['$http', '$q'];

    function LoginFactory($http, $q) {

        var service = {
            login: login
        };

        function login(emailAddress, password, rememberMe) {
            var deferredObject = $q.defer();

            $http.post(
                '/Account/Login', {
                    Email: emailAddress,
                    Password: password,
                    RememberMe: rememberMe
                }
            ).
            success(function (data) {
                if (data == "True") {
                    deferredObject.resolve({ success: true });
                } else {
                    deferredObject.resolve({ success: false });
                }
            }).
            error(function () {
                deferredObject.resolve({ success: false });
            });

            return deferredObject.promise;
        }

        return service;
    }
})();