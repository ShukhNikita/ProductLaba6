
//Функция удаления по id
async function DeleteCompanyById(id) {
	const response = await fetch("/api/company/" + id, {
		method: "DELETE",
		headers: { "Accept": "application/json" }
	});

	if (response.ok === true) {
		const company = await response.json();
		alert("Успешное удаление");
		document.querySelector("tr[data-rowid='" + company.id + "']").remove();
	}
}

//Функция для создания строки таблицы
function row(company) {
	const tr = document.createElement("tr");
	tr.setAttribute("data-rowid", company.id);

	const idTd = document.createElement("td");
	idTd.append(company.id);
	tr.append(idTd);

	const NameTd = document.createElement("td");
	NameTd.append(company.name);
	tr.append(NameTd);

	const GenreTd = document.createElement("td");
	GenreTd.append(company.fio);
	tr.append(GenreTd);

	const OwnershipFormId = document.createElement("td");
	OwnershipFormId.append(company.ownershipForm.name);
	tr.append(OwnershipFormId);

	const activityTypeTd = document.createElement("td");
	activityTypeTd.append(company.activityType.name);
	tr.append(activityTypeTd)

	const linksTd = document.createElement("td");

	const linkForEdit = document.createElement("a");
	linkForEdit.setAttribute("company-id", company.id);
	linkForEdit.append("Изменить")
	linkForEdit.addEventListener("click", event => {
		event.preventDefault();
		localStorage.setItem('id', company.id);
		window.location = "edit.html";
	});
	linksTd.append(linkForEdit);

	const linkForDelete = document.createElement("a");
	linkForDelete.setAttribute("company-id", company.id);
	linkForDelete.append("Удалить");
	linkForDelete.addEventListener("click", event => {
		event.preventDefault();
		DeleteCompanyById(company.id)
	});
	linksTd.append(linkForDelete);

	tr.append(linksTd);
	return tr;
}

