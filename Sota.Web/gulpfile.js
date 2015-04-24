var gulp = require('gulp');
var bower = require('gulp-bower');
var del = require('del');
var karma = require('karma').server;

var project = require('./project.json');
var lib = project.webroot + '/lib';

gulp.task('default', ['bower:install','test'], function () {
    return;
});

gulp.task('bower:install', ['clean'], function () {
    return bower({
        directory: lib
    });
});

gulp.task('clean', function (done) {
    del(lib, done);
});

/**
 * Run test once and exit
 */
gulp.task('test', function (done) {
    karma.start({
        configFile: __dirname + '/karma.conf.js',
        singleRun: true
    }, done);
});

/**
 * Watch for file changes and re-run tests on each change
 */
gulp.task('tdd', function (done) {
    karma.start({
        configFile: __dirname + '/karma.conf.js'
    }, done);
});
