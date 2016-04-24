(function () {
    'use strict';
    angular.module('dcs').factory('UsuarioFactory', UsuarioFactory);

    UsuarioFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function UsuarioFactory($http, $rootScope, SETTINGS) {
        return {
            obterPorId: obterPorId,
            getByEmail: getByEmail
        };

        function obterPorId(id) {
            var url = SETTINGS.SERVICE_URL + 'api/usuario/' + id + "/";

            return $http.get(url, $rootScope.header);
        }

        function getByEmail(email) {
            var url = SETTINGS.SERVICE_URL + 'api/login/usuarios/' + email + "/";

            return $http.get(url, $rootScope.header);
        }
    }
})();