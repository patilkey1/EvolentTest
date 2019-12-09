
app.service('contactService', function ($http) {
    // get all freatures
    this.GetAllContacts = function () {
        var url = apiURL + 'api/contact/GetAllContacts';
        return $http.get(url);
    };

    this.AddContact = function (ContactInfo) {
        var resp = $http({
            url: apiURL + "api/contact/AddUpdateContactInfo",
            method: "POST",
            data: ContactInfo,
        });
        return resp;
    };

    this.GetContactByID = function (ID) {
        var url = apiURL + 'api/contact/GetContactInfoById/' + ID;
        return $http.get(url);
    };
});