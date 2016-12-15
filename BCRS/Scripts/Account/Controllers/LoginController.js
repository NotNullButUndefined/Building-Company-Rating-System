(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$uibModal', '$routeParams', 'LoginFactory', '$window'];

    function LoginController($uibModal, $routeParams, LoginFactory, $window) {
        var vm = this;
        
        vm.openModal = function() {
            var ModalInstance = $uibModal.open({
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: 'LoginFailed.html',
                controller: 'loginFailedController',
                controllerAs: 'loginFailedCtrl',
                resolve: {
                    items: function () {
                        return vm.desc;
                    }
                }
            });
        };
        
        vm.loginForm = {
            emailAddress: '',
            password: '',
            rememberMe: false,
            returnUrl: $routeParams.returnUrl,
            loginFailure: false
        };

        vm.login = function () {
            var result = LoginFactory.login(vm.emailAddress, vm.password, vm.rememberMe);
            result.then(function(result) {
                if (result.success) {
                    if (!vm.loginForm.returnUrl) {
                        $window.location = ('/Account/UserPage');
                    }else {
                        $window.location = ($scope.loginForm.returnUrl);
                    }
                } else {
                    vm.openModal();
                }
            });
        }
    }
})();
