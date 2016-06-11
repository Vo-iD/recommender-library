var notificationManager = {
    showError: function (message, duration) {
        toastr.options = {
            "closeButton": true,
            "positionClass": "toast-top-full-width",
            "showDuration": "300",
            "hideDuration": "500",
            "timeOut": duration ? duration : 0
        };
        toastr.error(message, 'Error');
    },
    showSuccess: function (message, duration) {
        toastr.options = {
            "positionClass": "toast-top-center",
            "showDuration": "300",
            "hideDuration": "500",
            "timeOut": duration ? duration : 2500
        };
        toastr.success(message, 'Success');
    },
    showWarning: function (message, duration) {
        toastr.options = {
            "closeButton": true,
            "positionClass": "toast-top-center",
            "showDuration": "300",
            "hideDuration": "500",
            "timeOut": duration ? duration : 2500
        };
        toastr.warning(message, 'Warning');
    }
};