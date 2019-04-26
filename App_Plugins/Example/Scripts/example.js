angular.module('umbraco').controller('example.property.editor',
	['$scope', '$route', '$routeParams', '$location', '$q', '$timeout', 'localizationService',
	function ($scope, $route, $routeParams, $location, $q, $timeout, localizationService) {
			var vm = this;

		angular.extend(vm, {
			identifier: $scope.$id + (new Date().getTime()),
			loading: 0,
			edit: 1,
			saving: 2,
			saved: 3,
			error: 4,
			preview: 5,
			state: 0,
			connector: '',
			setErrorState: function () {
				vm.state = vm.error;
			},
			initConfig: function () {
				vm.state = vm.edit;
			},
			initEditor: function () {
				if (!angular.isUndefined($scope.model.sortOrder)) {
					vm.state = vm.preview;
					return;
				}

				try {
					if (typeof ($scope.model.value) === 'string') {
						$scope.model.value = ($scope.model.value != '') ? JSON.parse($scope.model.value) : null;
					}
					if (!$scope.model.value) {
						$scope.model.value = {};
					}
				}
				catch (oh) {
					$scope.model.value = {};
				}

				vm.connector = 'hello world';
				vm.state = vm.edit;
			},
		});
	}]
);

