var User = /** @class */ (function () {
    function User(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.visits = 0;
    }
    User.prototype.showName = function () {
        alert(this.firstName + " " + this.lastName);
    };
    Object.defineProperty(User.prototype, "name", {
        get: function () {
            return this.ourName;
        },
        set: function (val) {
            this.ourName = val;
        },
        enumerable: true,
        configurable: true
    });
    return User;
}());
//# sourceMappingURL=user.js.map