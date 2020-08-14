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
      '!themes/**/*.less'
    ])
    .pipe(less({
      javascriptEnabled: true,
      plugins: [new npmImport({ prefix: '~' })]
    }))
    .pipe(concatCss('ant-design-pro-layout-blazor.css'))
    .pipe(cleanCss({ compatibility: '*' }))
    .pipe(gulp.dest('wwwroot/css'));
});

gulp.task('themes', function () {
  return gulp.src([
    'themes/**/*.less',
    '!themes/components.less',
  ])
  .pipe(less({
    javascriptEnabled: true,
    plugins: [new npmImport({ prefix: '~' })]
  }))
  .pipe(cleanCss({ compatibility: '*' }))
  .pipe(rename({dirname: 'wwwroot/theme'}))
  .pipe(gulp.dest('./'));
});

gulp.task('default', gulp.parallel('less', 'themes'), function () { });