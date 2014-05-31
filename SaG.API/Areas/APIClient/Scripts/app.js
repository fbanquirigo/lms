angular.module('app', ['components', 'client', 'controllers']);

$(document).keydown(function (e) {
    if (e.which !== 8)
        return;
    var nodeName = e.target.nodeName.toLowerCase();
    if ((nodeName === 'input' && e.target.type === 'text') || nodeName === 'textarea')
        return;
    e.preventDefault();
});


