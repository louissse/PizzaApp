"use strict";

var _ = require('lodash'),
    gulp = require('gulp');

gulp.task('copy-assets', function () {
    var assets = {
        js: [
            './node_modules/bootstrap/dist/js/bootstrap.js'
        ],
        css: ['./node_modules/bootstrap/dist/css/bootstrap.css']
    };
    _(assets).forEach(function (assets, type) {
        gulp.src(assets).pipe(gulp.dest('./wwwroot/' + type));
    });
});