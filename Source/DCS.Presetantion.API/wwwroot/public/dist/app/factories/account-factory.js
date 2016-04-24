(function () {
    'use strict';
    angular.module('dcs').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$http', 'SETTINGS'];

    function AccountFactory($http, SETTINGS)
    {
        var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

        return {
            login: login,
            logout: logout
        };

        function login(data) {
            var dt = "grant_type=password&username=" + data.email + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';            

            return $http.post(url, dt, header);
        }

        function logout(userId) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/logout/usuarios/' + userId + "/", header);
        }
    }
})();