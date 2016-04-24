(function () {
    'use strict';
    angular.module('dcs').controller('LogoutCtrl', LogoutCtrl);

    LogoutCtrl.$inject = ['$rootScope', '$location', 'SETTINGS', 'AccountFactory'];

    function LogoutCtrl($rootScope, $location, SETTINGS, AccountFactory) {
        var vm = this;

        activate();

        function activate() {

            AccountFactory.logout($rootScope.userId);

            $rootScope.user = null;
            $rootScope.token = null;
            $rootScope.userId = null;
            sessionStorage.removeItem(SETTINGS.AUTH_TOKEN);
            sessionStorage.removeItem(SETTINGS.AUTH_USER);
            sessionStorage.removeItem(SETTINGS.AUTH_ID);

            $location.path('/login');
        }
    };
})();