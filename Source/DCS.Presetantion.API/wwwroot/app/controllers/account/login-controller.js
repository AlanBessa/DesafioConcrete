(function () {
    'use strict';
    angular.module('dcs').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$rootScope', '$location', 'SETTINGS', 'AccountFactory', 'UsuarioFactory'];

    function LoginCtrl($rootScope, $location, SETTINGS, AccountFactory, UsuarioFactory) {

        var vm = this;

        vm.login = {
            email: '',
            password: ''
        };

        vm.submit = login;

        activate();

        function activate() { };

        function login()
        {
            AccountFactory.login(vm.login)
                 .success(success)
                 .catch(fail);

            function success(response)
            {
                $rootScope.token = response.access_token;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);

                UsuarioFactory.getByEmail(vm.login.email)
                    .success(finalSuccess)
                    .catch(fail);                
            }

            function finalSuccess(response) {
                $rootScope.user = response.nome;
                $rootScope.userId = response.idUsuario;                
                sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
                sessionStorage.setItem(SETTINGS.AUTH_ID, $rootScope.userId);
                $location.path('/');
            }

            function fail(error) {
                $rootScope.token = null;
                sessionStorage.removeItem(SETTINGS.AUTH_TOKEN);
                toastr.error(error.data.error_description, 'Falha na autenticação');
            }
        }
    };
})();