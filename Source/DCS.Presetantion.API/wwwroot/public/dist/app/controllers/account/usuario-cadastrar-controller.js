(function () {
    'use strict';
    angular.module('dcs').controller('UsuarioCadastrarCtrl', UsuarioCadastrarCtrl);

    UsuarioCadastrarCtrl.$inject = ['$scope', '$location', 'UsuarioFactory'];

    function UsuarioCadastrarCtrl($scope, $location, UsuarioFactory) {
        var vm = this;
        
        vm.listaTelefones = [];
        vm.telefone = {
            ddd: '',
            numero:''
        };


        vm.usuario = {
            nome: '',
            email: '',
            senha: '',
            telefones: []
        };

        vm.adicionarTelefone = adicionarTelefone;
        vm.removerTelefone = removerTelefone;
        vm.submit = salvarUsuario;
        activate();

        function activate() {

        }

        function adicionarTelefone()
        {
            if (vm.telefone.ddd == undefined || vm.telefone.numero == undefined) return;
            
            vm.listaTelefones.push(vm.telefone);
            vm.telefone = {};                        
        }

        function removerTelefone(telefone) {
            toastr.success('Telefone <strong>' + telefone.ddd + " " + telefone.numero + '</strong> removido com sucesso.', 'Sucesso');

            var index = vm.listaTelefones.indexOf(telefone);
            vm.listaTelefones.splice(index, 1);
        }

        function salvarUsuario() {
            vm.usuario.telefones = vm.listaTelefones;

            UsuarioFactory.salvarUsuario(vm.usuario)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Usuário <strong>' + response.nome + '</strong> cadastrado com sucesso.', 'Sucesso');
                $location.path('/login');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }        
    };
})();