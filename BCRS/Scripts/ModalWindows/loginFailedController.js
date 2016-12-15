(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginFailedController', loginFailedController);

    loginFailedController.$inject = ['$uibModalInstance'];

    function loginFailedController($uibModalInstance) {
        
        var loginFailedCtrl = this;

        loginFailedCtrl.ok = function () {
            $uibModalInstance.close();
        };

        loginFailedCtrl.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

    }
})();
