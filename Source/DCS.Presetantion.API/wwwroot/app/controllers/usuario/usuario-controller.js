(function () {
    'use strict';
    angular.module('dcs').controller('UsuarioCtrl', UsuarioCtrl);

    UsuarioCtrl.$inject = ['$rootScope', '$location', 'UsuarioFactory'];

    function UsuarioCtrl($rootScope, $location, UsuarioFactory) {
        var vm = this;
        var id = $rootScope.userId;

        vm.usuario = {};
        activate();

        function activate() {
            obterPerfil();
        };

        function obterPerfil() {
            UsuarioFactory.obterPorId(id) 
                .success(success)
                .catch(fail);

            function success(response) {
                if (angular.equals(response.token, $rootScope.token))
                {
                    vm.usuario = response;
                }
                else
                {
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                    $location.path('/');
                }
            }

            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else
                    toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }
    };
})();