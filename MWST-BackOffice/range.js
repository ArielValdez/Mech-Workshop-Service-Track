module.exports = (req, res, next) => {
    res.header({
      'Access-Control-Expose-Headers': 'Content-Range',
      'Content-Range': 'posts 0-20/20',
    })
    next();
}