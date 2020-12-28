
var app = new Vue({
	el: '#addFeedback',
	data: {
		Comment: ""
	},
	methods: {
		submit() {
			if (this.Comment != "") {
				axios
					.post("/api/Feedback", {
						Comment: this.Comment
					}).then(response => {
						JSAlert.alert("Your feedback has been saved!");

						setTimeout(function () {
							if (window.location.hash != '#r') {
								window.location.hash = 'r';
								window.location.reload(1);
							}
						}, 3000);


					})
			} else {
				JSAlert.alert("You have to fill in the form");
			}

		}
	}
})