//Функция получения данных и занесения в таблицу 
async function GetAllCompanies() {
	const response = await fetch("/api/company", {
		method: "GET",
		headers: { "Accept": "application/json" }
	});

	if (response.ok === true) {
		const companies = await response.json();
		let rows = document.querySelector("tbody");
		companies.forEach(company => {
			rows.append(row(company));
		});
	}
}

//Функция получения форм собственности в элемент html-разметки (select)
async function GetAllOwnerships() {
	var selectList = companyForm.ownershipForm;
	const response = await fetch("/api/ownershipForm", {
		method: "GET",
		headers: { "Accept": "application/json" }
	});
	if (response.ok === true) {
		const ownerships = await response.json();
		ownerships.forEach(ownership => {
			var option = document.createElement("option");
			option.text = ownership.name;
			option.value = parseInt(ownership.id);
			selectList.append(option)
		});
	}
}

//Функция получения всех типов производства в элемент html-разметки (select)
async function GetAllActivityTypes() {
	var selectList = companyForm.activityType;
	const response = await fetch("/api/activityType", {
		method: "GET",
		headers: { "Accept": "application/json" }
	});
	if (response.ok === true) {
		const activityTypes = await response.json();
		activityTypes.forEach(activityType => {
			var option = document.createElement("option");
			option.text = activityType.name;
			option.value = parseInt(activityType.id);
			selectList.append(option);
		});
	}
}
