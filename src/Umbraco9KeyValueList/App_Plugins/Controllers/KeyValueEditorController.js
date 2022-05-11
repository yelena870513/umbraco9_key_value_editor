angular.module('umbraco').controller('KeyValueEditorController', ['$scope', 'editorService', 'keyValueEditorConfigService', function($scope, editorService, keyValueEditorConfigService) {

  $scope.model.value = $scope.model.value || []

  if (!($scope.model.value instanceof Array))
    $scope.model.value = []

  $scope.cfg = keyValueEditorConfigService.get($scope.model.config)

  /* Events */
  $scope.addKeyValue = function($event) {

    $event.preventDefault()
    $event.stopPropagation()
    let options = {
      title: 'Key Value List Editor',
      view: '/App_Plugins/Umbraco9KeyValueList/Views/KeyValueEditorDialogView.html',
      size: 'small',
      dialogData: { config: $scope.cfg },
      submit: function(model) {
        done(model)
        editorService.close()
      },
      close: function() {
        editorService.close()
      }
    }
    editorService.open(options)

    function done(data) {
      if (data.key && data.value)
        $scope.model.value.push({ key: data.key, value: data.value, description: data.description })
    }
  }

  $scope.editKeyValue = function(item) {
    let options = {
      title: 'Key Value List Editor',
      view: '/App_Plugins/Umbraco9KeyValueList/Views/KeyValueEditorDialogView.html',
      size: 'small',
      dialogData: { key: item.key, value: item.value, description: item.description, config: $scope.cfg },
      submit: function(model) {
        done(model)
        editorService.close()
      },
      close: function() {
        editorService.close()
      }
    }
    editorService.open(options)

    function done(data) {
      if (data.key && data.value) {

        for (var i = 0; i < $scope.model.value.length; i++) {
          if ($scope.model.value[i].key == item.key) {
            $scope.model.value[i] = data
            break
          }
        }
      }
    }
  }

  $scope.deleteKeyValue = function(item) {
    var index = $scope.model.value.indexOf(item)
    $scope.model.value.splice(index, 1)
  }
  /* End Events */

  /* Sorting */
  $scope.predicate = ($scope.cfg.useSortableHeaders) ? 'value' : null
  $scope.reverse = true
  $scope.order = function(predicate) {
    console.log(predicate)
    $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false
    console.log($scope.reverse)
    $scope.predicate = predicate
  }
  /* End Sorting */
}])