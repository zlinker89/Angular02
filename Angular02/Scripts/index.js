Array.prototype.remove = function (value) {
    var idx = this.indexOf(value);
    if (idx != -1) {
        return this.splice(idx, 1); // The second parameter is the number of elements to remove.
    }
    return false;
}
var personas = [];

angular.module("eva", []).controller("control1", function ($scope) {

    $scope.addPersona = function () {
        var p = {
            nombres: $scope.nombres,
            apellidos: $scope.apellidos
        };
        $scope.nombres = "";
        $scope.apellidos = "";

        personas.push(p);
        $scope.personas = personas;
    }

    $scope.deletePersona = function (p) {
        personas.remove(p);
        $scope.personas = personas;
    }


});