/// <binding BeforeBuild='dev' />

var gulp = require('gulp');

require('./gulp/tasks/default');

gulp.task('default', gulp.series('assets', 'sass', 'govjs', 'js', 'sitemap', 'purifycss',
    (done) => {
        done();
    }));