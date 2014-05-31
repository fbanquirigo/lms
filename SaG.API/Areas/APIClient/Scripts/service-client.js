var app = angular.module('client', []);

// Config Service
app.service('APIConfigService', function () {
    var baseUri = '/';
    var accessToken = '';

    this.setAccessToken = function(token) {
        accessToken = token;
    };

    this.getAccessToken = function() {
        return accessToken;
    };

    this.setBaseUri = function(uri) {
        baseUri = uri;
    };

    this.getBaseUri = function() {
        return baseUri;
    };

    this.getHeaders = function() {
        return {
            'Content-Type': 'application/json',
            'Authentication-Token': accessToken
        };
    };
});

// API Service
app.service('APIService', function ($http, APIConfigService) {
    this.execute = function (methodName, data, success, error) {
        var url = APIConfigService.getBaseUri() + methodName;
        var headers = APIConfigService.getHeaders();
        $http({            
            url: url,
            method: 'POST',
            headers: headers,
            data: data
        }).success(success).error(error);
    };
});

// Access
app.controller('operator', function ($scope, APIService) {
    $scope.logout = function (success, error) {
        APIService.execute('logout/access_token', {},
            function (data, status, headers, config) {
                if (success)
                    success(data, status, headers, config);
            }, function (data, status, headers, config) {
                if (error)
                    error(data, status, headers, config);
            });
    };
});


// A Series
app.controller('openLockA', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        UserId: null,
        TouchKeyId: null,
        Date: null,
        Hour: 0,
        TimeBlock: 4,
        LockStatus: 0
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);
        
        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function() {
        return 'POST';
    };

    $scope.getMethodName = function() {
        return 'OPEN_LOCK_A';
    };

    $scope.getUri = function() {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function() {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if(init)
            init();
    };

    var initResultVariables = function() {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('openLockNoTouchKeyA', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        UserId: null,
        Date: null,
        Hour: 0,
        TimeBlock: 4,
        LockStatus: 0
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_NO_TOUCH_KEY_A';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };
    
    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('openLockNow1A', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        UserId: null
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_NOW_1_A';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };
    
    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('openLockNow2A', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        UserId: null
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_NOW_2_A';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('closeCodeA', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        OperationCode: null,
        OperationResult: null
    };
    $scope.codeClosed = null;
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.codeClosed = data.Body.CodeClosed;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'CLOSE_CODE_A';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.codeClosed = null;
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('closeCodeViaSealA', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        UserId: null,
        OperationResult: null
    };
    $scope.codeClosed = null;
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.codeClosed = data.Body.CodeClosed;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'CLOSE_CODE_A_SEAL_A';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.codeClosed = null;
        $scope.status = 0;
        $scope.message = '';
    };
});


// B Series
app.controller('openLockB', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        LockId: null,
        UserId: null,
        TouchKeyId: null,
        Date: null,
        Hour: 0,
        TimeBlock: 4,
        LockStatus: 0
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_B';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

app.controller('openLockNow1B', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        UserId: null
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_NOW_1_B';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});

// C Series
app.controller('openLockC', function ($scope, APIService, APIConfigService) {

    $scope.request = {
        AtmId: null,
        MiddleName: null,
        TouchKeyId: null,
        Date: null,
        Hour: 0,
        TimeBlock: 4,
        LockStatus: 0
    };
    $scope.operationCode = '';
    $scope.status = 0;
    $scope.message = '';

    $scope.execute = function (before, success, error) {
        initResultVariables();
        if (before)
            before($scope.request);

        APIService.execute($scope.getMethodName(), $scope.request,
            function (data, status, headers, config) {
                $scope.response = data;
                $scope.status = data.Header.StatusCode;
                if (data.Header.StatusCode === 0) {
                    $scope.operationCode = data.Body.OperationCode;
                } else {
                    $scope.message = data.Header.Message;
                }
                if (success)
                    success($scope.response, status, headers, config);
            }, function (data, status, headers, config) {
                $scope.response = data;
                if (error)
                    error($scope.response, status, headers, config);
            });
    };

    $scope.getMethod = function () {
        return 'POST';
    };

    $scope.getMethodName = function () {
        return 'OPEN_LOCK_C';
    };

    $scope.getUri = function () {
        return APIConfigService.getBaseUri() + $scope.getMethodName();
    };

    $scope.getHeaders = function () {
        return APIConfigService.getHeaders();
    };

    $scope.init = function (init) {
        if (init)
            init();
    };

    var initResultVariables = function () {
        $scope.operationCode = '';
        $scope.status = 0;
        $scope.message = '';
    };
});
