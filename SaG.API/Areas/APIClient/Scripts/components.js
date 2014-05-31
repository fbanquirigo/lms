var app = angular.module('components', ['ngSanitize']);

app.directive('tabs', function() {
    return {
        restrict: 'E',
        transclude: true,
        scope: {},
        controller: function($scope, $element) {
            var panes = $scope.panes = [];

            $scope.select = function(pane) {
                angular.forEach(panes, function(pane) {
                    pane.selected = false;
                });
                pane.selected = true;
            };

            this.addPane = function(pane) {
                if (panes.length == 0) $scope.select(pane);
                panes.push(pane);
            };
        },
        templateUrl: '/client/templates/tabs',
        replace: true
    };
});

app.directive('pane', function() {
    return {
        require: '^tabs',
        restrict: 'E',
        transclude: true,
        scope: { title: '@' },
        link: function(scope, element, attrs, tabsCtrl) {
            tabsCtrl.addPane(scope);
        },
        templateUrl: '/client/templates/pane',
        replace: true
    };
});

app.directive('panel', function () {
    return {
        restrict: 'E',
        transclude: true,
        scope: { title: '@' },
        templateUrl: '/client/templates/panel',
        replace: true
    };
});

app.directive('requestcontrol', function () {
    return {
        restrict: 'E',
        transclude: false,
        scope: {
            method: '=',
            url: '=',
            request: '=',
            response: '=',
            headers: '='
        },
        templateUrl: '/client/templates/requestControl',
        replace: false
    };
});

app.directive('compile', ['$compile', function ($compile) {
    return function (scope, element, attrs) {
        scope.$watch(
        function (scope) {
            return scope.$eval(attrs.compile);
        },
        function (value) {
            element.html(value);
            $compile(element.contents())(scope);
        });
    };
}]);

app.directive('json', function () {
    return {
        restrict: 'A', // only activate on element attribute
        require: 'ngModel', // get a hold of NgModelController
        link: function (scope, element, attrs, ngModelCtrl) {
            function fromUser(text) {
                // Beware: trim() is not available in old browsers
                if (!text || text.trim() === '')
                    return {}
                else
                    // TODO catch SyntaxError, and set validation error..
                    return angular.fromJson(text);
            }

            function toUser(object) {
                // better than JSON.stringify(), because it formats + filters $$hashKey etc.
                return angular.toJson(object, true);
            }

            // push() if faster than unshift(), and avail. in IE8 and earlier (unshift isn't)
            ngModelCtrl.$parsers.push(fromUser);
            ngModelCtrl.$formatters.push(toUser);

            // $watch(attrs.ngModel) wouldn't work if this directive created a new scope;
            // see http://stackoverflow.com/questions/14693052/watch-ngmodel-from-inside-directive-using-isolate-scope how to do it then
            scope.$watch(attrs.ngModel, function (newValue, oldValue) {
                if (newValue != oldValue) {
                    ngModelCtrl.$setViewValue(toUser(newValue));
                    // TODO avoid this causing the focus of the input to be lost..
                    ngModelCtrl.$render();
                }
            }, true); // MUST use objectEquality (true) here, for some reason..
        }
    };
});