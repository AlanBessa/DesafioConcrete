module.exports = function(grunt) {
  grunt.initConfig({  
      cssmin: {
          sitecss:{
              files:{
                  'public/dist/assets/cssmin/styles-1.0.0.min.css':[
                      'bower_components/bootswatch/sandstone/bootstrap.css',
                      'bower_components/animate.css/animate.css',
                      'bower_components/font-awesome/css/font-awesome.css',
                      'bower_components/toastr/toastr.css'
                  ]                
              }
          }
      },    
      uglify: {        
          options: {        
              compress: true
          },
          applib: {
              src: [
                'bower_components/jquery/dist/jquery.js',
                'bower_components/bootstrap/dist/js/bootstrap.js',
                'bower_components/toastr/toastr.js',
                'bower_components/angular/angular.js',
                'bower_components/angular-route/angular-route.js'
              ],
              dest: 'public/dist/assets/js/scripts-1.0.0.min.js'
          }
      },
      copy: {
          main:{
              files: [{
                  expand: true,
                  cwd: "bower_components/font-awesome/fonts",
                  src: '**',
                  dest: 'public/dist/assets/fonts',
                  flatten: false
              }],
              files: [{
                  expand: true,
                  cwd: 'app',
                  src: '**',
                  dest: 'public/dist/app',
                  flatten: false
              }]
          }
      },
      htmlmin: {
          dist: {
              options: {
                  removeComments: true,
                  collapseWhitespace: true
              },
              files: {
                  'public/dist/pages/shared/headerbar.html': 'public/dev/pages/shared/headerbar.html',
                  'public/dist/pages/account/cadastrar.html': 'public/dev/pages/account/cadastrar.html',
                  'public/dist/pages/account/login.html': 'public/dev/pages/account/login.html',
                  'public/dist/pages/home/index.html': 'public/dev/pages/home/index.html',
                  'public/dist/pages/perfil/index.html': 'public/dev/pages/perfil/index.html'
              }
          }
      }
  });

  // Default task.
  grunt.registerTask('dist', ['cssmin', 'copy', 'htmlmin', 'uglify']);

  // These plugins provide necessary tasks.{% if (min_concat) { %}
  grunt.loadNpmTasks('grunt-contrib-cssmin');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-htmlmin');
  grunt.loadNpmTasks('grunt-contrib-copy'); 

};
