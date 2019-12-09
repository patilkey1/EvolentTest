
var isvoted = false;
app.controller('contactController', function ($scope, contactService) {

    $scope.emailFormat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    $scope.phoneno = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;


    $scope.init = function () {
    }

    //$scope.Add = function () {
    //    $scope.GetAllContacts();
    //}

    function getUrlParameter(name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(window.location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    };

    $scope.Edit = function (ID) {
        $scope.loadingStatus = false;
        var navigate = "AddUpdate.html";
        if (ID != null) {
            navigate = navigate + "?ID=" + ID
        }
        window.location = navigate;
    }

    $scope.CheckEditable = function () {
        //$scope.loadingStatusV2 = false;
        $scope.ContactID = getUrlParameter('ID');
        if ($scope.ContactID != '') {
            $scope.loadingStatusV2 = true;
            var servecall = contactService.GetContactByID($scope.ContactID);
            servecall.then(function (resp) {
                $scope.firstName = resp.data.firstName;
                $scope.lastName = resp.data.lastName;
                $scope.Email = resp.data.Email;
                $scope.PhoneNumber = resp.data.PhoneNumber;
                $scope.isActive = resp.data.isActive;
                $scope.loadingStatusV2 = false;
            }, function (err) {
                $scope.ErrorData = "Error " + err.status;
                $scope.loadingStatusV2 = false;
            })
        }
        $scope.loadingStatusV2 = false;
    }

    $scope.Cancel = function () {
        window.location = "Index.html";
    }

    $scope.GetContacts = function () {
        $scope.loadingStatus = true;
        var servecall = contactService.GetAllContacts();
        servecall.then(function (resp) {
            $scope.ContactList = resp.data;
            $scope.loadingStatus = false;
        }, function (err) {
            $scope.ErrorData = "Error " + err.status;
            $scope.loadingStatus = false;
        })
    }

    $scope.AddContactInfo = function () {
        $scope.loadingStatus = true;
        $scope.submitted = true;
        if ($scope.registerForm.$valid) {
            $scope.responseData = "";

            var ContactInfo = {
                firstName: $scope.firstName,
                lastName: $scope.lastName,
                Email: $scope.Email,
                PhoneNumber: $scope.PhoneNumber,
                isActive: $scope.isActive,
                ID: $scope.ContactID,

            };

            var promiseregister = contactService.AddContact(ContactInfo);
            promiseregister.then(function (resp) {
                $scope.loadingStatus = false;
                switch (resp.data) {
                    case '1':
                        alert('Contact Added Successfully');
                        window.location = "Index.html";
                        break;
                    case '2':
                        alert('Contact Updated Successfully');
                        window.location = "Index.html";
                        break;
                    case '0':
                        alert('Error in processing request. Please try again.');
                        window.location = "Index.html";
                        break;
                }
            }, function (err) {
                $scope.loadingStatus = false;
            })
        }
        else {
            console.log("Please correct errors!");
            $scope.loadingStatus = false;
        }
    };

    $scope.UpdateActive = function (State) {
        $scope.IsActive = State;
    }

});
