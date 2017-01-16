module.exports = function (grunt) {

    grunt.initConfig({

        bower: {
            install: {
                //just run 'grunt bower:install'
            }
        },

        clean: [
            "Scripts/js",
            "Content/styles"
        ],

        copy: {
            main: {
                files: [
                    { expand: true, cwd: "bower_components/jquery/dist", src: "jquery.min.js", dest: "Scripts/js" },
                    { expand: true, cwd: "bower_components/jquery-validation/dist", src: "jquery.validate.min.js", dest: "Scripts/js" },
                    { expand: true, cwd: "bower_components/jquery-validation-unobtrusive", src: "jquery.validate.unobtrusive.min.js", dest: "Scripts/js" },
                    { expand: true, cwd: "bower_components/respond/dest", src: "respond.min.js", dest: "Scripts/js" },
                    { expand: true, cwd: "bower_components/bootstrap/dist/js", src: "bootstrap.min.js", dest: "Scripts/js" },
                    { expand: true, cwd: "bower_components/bootstrap/dist/css", src: "bootstrap.min.css", dest: "Content/styles" },
                    { expand: true, cwd: "bower_components/bootstrap/dist/css", src: "bootstrap-theme.min.css", dest: "Content/styles" },
                    { expand: true, cwd: "bower_components/bootstrap/dist/fonts", src: "*.*", dest: "fonts" }
                ]
            }
        },

    });

    grunt.registerTask("default", ["bower", "clean", "copy"]);

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks('grunt-bower-task');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
};