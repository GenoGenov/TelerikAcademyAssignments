var usersController = require('../controllers/usersController');
var uploadsController = require('../controllers/UploadsController');
var downloadsController=require('../controllers/DownloadsController');

module.exports = {
    users: usersController,
    uploads:uploadsController,
    downloads:downloadsController
};