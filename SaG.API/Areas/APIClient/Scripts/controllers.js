var app = angular.module('controllers', []);

app.controller('UIController', function ($scope, $http, $templateCache, APIConfigService) {

    $scope.init = function () {
        APIConfigService.setBaseUri('/');
        var accessToken = getAccessToken();
        APIConfigService.setAccessToken(accessToken);
        
        var url = '/client/menu';
        $http.get(url, { cache: $templateCache }).success(function (data) {
            $scope.menus = data;
        });
    };

    $scope.menuClick = function (menu) {
        if (menu.action) {
            menu.action();
            return;
        }
        if (menu.Location === 'dashboard') {
            $scope.showFormInDashboard(menu.Form);
        } else if (menu.Location === 'modal') {
            $scope.showFormInModal(menu.Form);
        }
    };

    $scope.showFormInDashboard = function (formName) {
        showDashboardLoader();
        var url = '/client/forms/' + formName;
        if ($scope.isDebug())
            url += '/debug';
        $http.get(url, { cache: $templateCache }).success(function (data) {
            hideDashboardLoader();
            $scope.dashboardContent = data;
        }).error(function () {
            $http.get('/client/forms/error', { cache: $templateCache }).success(function(data) {
                hideDashboardLoader();
                $scope.dashboardContent = data;
            }).error(function() {
                hideDashboardLoader();
                $scope.dashboardContent = '<h1>Error</h1>';
            });
        });
    };
    
    $scope.beforeMethodExecute = function (request) {
        showExecuteLoader();
    };

    $scope.methodExecuteSuccess = function (response, status, headers, config) {
        hideExecuteLoader();
    };

    $scope.methodExecuteError = function (response, status, headers, config) {
        if (status == 404) {
            show404Message();
            hideExecuteLoader();
        } else if (status === 403) {
            goToLogout();
        }
    };

    $scope.logoutSuccess = function (response, status, headers, config) {
        goToLogout();
    };

    $scope.toJson = function(model) {
        return angular.toJson(model, true);
    };

    $scope.isDebug = function() {
        return isDebug();
    };

    $scope.initControls = function() {
        initControls();
    };
});

// Misc
var getAccessToken = function() {
    return $('#AccessToken').val();
};

var showDashboardLoader = function() {
    var dashboardLoader = $('.dashboard-loader');
    var dashboard = $('#dashboard');
    dashboard.css("display", "none");
    dashboardLoader.css("display", "block");
};

var hideDashboardLoader = function() {
    var dashboardLoader = $('.dashboard-loader');
    var dashboard = $('#dashboard');
    dashboard.css("display", "block");
    dashboardLoader.css("display", "none");
};

var showExecuteLoader = function () {
    $('#btnExecute').css("display", "none");
    $('#loader').css("display", "block");
};

var hideExecuteLoader = function () {
    $('#btnExecute').css("display", "block");
    $('#loader').css("display", "none");
};

var initControls = function () {
    $('.datepicker').datepicker({
        orientation: "auto right",
        todayHighlight: true,
        autoclose: true,
    });
};

var show404Message = function () {
    $('#txtResult').val("Error 404");
};

var goToLogout = function () {
    window.location.href = "/client/logout";
};

var isDebug = function() {
    var debugString = $('#Debug').val();
    return (debugString === 'debug');
};

