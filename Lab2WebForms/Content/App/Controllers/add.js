angular.module('Billboard').controller('AddCtrl', ['$scope', '$modal', '$log', '$rootScope',
    function ($scope, $modal, $log, $rootScope) {
        
    }]);

angular.module('Billboard').controller('ModalAddCtrl', ['$scope', '$modalInstance', '$location', 'Auth', '$rootScope',
    function ($scope, $modalInstance, $location, Auth, $rootScope) {

        $rootScope.m = $modalInstance;

        $scope.setFocus = function (elem) {
            $scope.elem = elem;
        };

        $scope.closePopup = function () {
            $modalInstance.dismiss('cancel');
            $location.path('/');
        };

    }]);