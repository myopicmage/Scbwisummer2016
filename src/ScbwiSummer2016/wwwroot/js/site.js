// Write your Javascript code.

var app = angular.module("scbwi", []);

app.controller("ScbwiController", function ($http) {
    var self = this;

    self.step1 = true;
    self.step2 = false;

    self.locations = [];

    self.calculate = function () {
        self.step1 = false;
        self.step2 = true;
    }

    self.submit = function () {
        var tosend = {
            r: self.model
        };

        console.log(tosend);

        $http({
            method: 'post',
            url: '/home/submit',
            data: JSON.stringify(self.model)
        })
        .then(function (data, status, headers, config) {
            self.model.total = data.data.total;
            self.model.usedcode = data.data.usedcode;
            self.step1 = false;
            self.step2 = true;
        }, function (data, status, headers, config) {
            console.log(data);
        });
    }

    $http({ method: 'post', url: '/home/locations' })
        .then(function (data, status, headers, config) {
            self.locations = data.data;
        });
});