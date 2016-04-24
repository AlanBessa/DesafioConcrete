(function () {
    'use strict';

    angular.module('dcs').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'dcs-token',
        'AUTH_USER': 'dcs-user',
        'AUTH_ID': 'dcs-id',
        'SERVICE_URL': '/'
        //'SERVICE_URL':'http://'
    });

    angular.module('dcs').run(function ($rootScope, $location, SETTINGS)
    {
        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);
        var user = sessionStorage.getItem(SETTINGS.AUTH_USER);
        var userId = sessionStorage.getItem(SETTINGS.AUTH_ID);

        $rootScope.user = null;
        $rootScope.userId = null;
        $rootScope.token = null;
        $rootScope.header = null;

        if (token && user) {
            $rootScope.user = user;
            $rootScope.token = token;
            $rootScope.userId = userId;
            $rootScope.header = {
                header: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            }
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current)
        {
            if ($rootScope.user == null)
            {
                if (next.templateUrl === "pages/account/cadastrar.html") {
                    $location.path('/usuario/perfil/cadastrar');
                }
                else {
                    $location.path('/login');
                }
                
            }
        });
    });
})();