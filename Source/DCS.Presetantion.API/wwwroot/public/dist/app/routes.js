(function () {
    'use strict';

    angular.module('dcs').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/home/index.html'
            }).when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/login.html'
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/login.html'
            })
            .when('/usuario/perfil/cadastrar', {
                controller: 'UsuarioCadastrarCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/account/cadastrar.html'
            })
            .when('/usuario/perfil', {
                controller: 'UsuarioCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/perfil/index.html'
            });
    });
})();