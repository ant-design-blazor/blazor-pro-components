var gulp = require('gulp'),
  cleanCss = require('gulp-clean-css'),
  less = require('gulp-less'),
  rename = require('gulp-rename'),
  concatCss = require("gulp-concat-css"),
  npmImport = require("less-plugin-npm-import");

gulp.task('less', function () {
  return gulp
    .src([
        '**/*.less',
    ])
    .pipe(less({
        javascriptEnabled: true,
        plugins: [new npmImport({ prefix: '~' })]
      }))
    .pipe(concatCss('app.css'))
    .pipe(cleanCss({ compatibility: '*' }))
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('default', gulp.parallel('less'), function () { })