module.exports = function (grunt) {
    grunt.initConfig({

        coffee: {
            compile: {
                files: {
                    'dev/scripts/result.js': 'app/scripts/**/*.coffee'
                }
            }
        },

        jshint: {
            all: ['Gruntfile.js', 'dev/scripts/**/*.js']
        },

        jade: {
            compile: {
                options: {
                    data: {
                        debug: false
                    }
                },
                files: {
                    "dev/html/result.html": ["app/views/**/*.jade"]
                }
            }
        },

        stylus: {
            compile: {
                options: {
                    compress: false

                },
                files: {
                    'dev/styles/result.css': 'app/styles/**/*.styl'
                }
            }
        },
        copy: {
            main: {
                files: [
                    {expand: true, cwd:'app/images/', src: ['**/*'], dest: 'dev/images/', filter: 'isFile'}
                ]
            }
        },
        connect: {
            options: {
                port: 9678,
                livereload: 35729,
                hostname: 'localhost'
            },
            livereload: {
                options: {
                    open: true,
                    base: [
                        'dev'
                    ]
                }
            }
        },
        watch: {
            stylus: {
                files: 'app/styles/**/*.styl',
                tasks: ['stylus'],
                options: {
                    livereload: true
                }
            },
            coffee: {
                files: 'app/scripts/**/*.coffee',
                tasks: ['coffee', 'jshint'],
                options: {
                    livereload: true
                }
            },
            jade: {
                files: 'app/views/**/*.jade',
                tasks: ['jade'],
                options: {
                    livereload: true
                }
            },
            js:{
                files:'Gruntfile.js',
                tasks:[],
                options:{
                    livereload:true
                }
            },
            livereload: {
                options: {
                    livereload: '<%= connect.options.livereload %>'
                },
                files: [
                    'dev/**/*.html',
                    'dev/**/*.css',
                    'dev/**/*.js'
                ]
            }
        }

    });

    require('load-grunt-tasks')(grunt);
    grunt.registerTask('serve', [
        'coffee', 'jade', 'stylus', 'copy', 'connect', 'watch'
    ]);
};
