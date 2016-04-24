(function () {
    'use strict';
    angular.module('dcs').factory('UsuarioFactory', UsuarioFactory);

    UsuarioFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function UsuarioFactory($http, $rootScope, SETTINGS) {
        return {
            obterPorId: obterPorId,
            obterUsuarioAutenticadoPorEmail: obterUsuarioAutenticadoPorEmail
        };

        function obterPorId(id) {
            var url = SETTINGS.SERVICE_URL + 'api/usuario/' + id + "/";

            return $http.get(url, $rootScope.header);
        }

        function obterUsuarioAutenticadoPorEmail(email) {
            var data = angular.toJson({ 'email': email, 'token': $rootScope.token });
            var url = SETTINGS.SERVICE_URL + 'api/login/usuarios/';

            return $http.post(url, data, $rootScope.header);
        }
    }
})();