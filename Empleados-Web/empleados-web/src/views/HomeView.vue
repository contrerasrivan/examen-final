<script setup lang="ts">
//Imports table
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
//import ColumnGroup from 'primevue/columngroup';   // optional
//import Row from 'primevue/row';                   // optional

//Import botones

import Button from 'primevue/button';

import {ref,onMounted} from 'vue';

const urlEmpleados = "http://localhost:5000/api/empleados"
const listaempleados= ref([])

const getEmpleados = async ()=>{
  const response = await fetch(urlEmpleados)
  const data = await response.json()
  listaempleados.value = data.empleadosList // se coloca la llamada del response de la api para guardar lso datos
}

/*
const postEmpleados = async()=>{
  const newEmpleado = getEmpleados()
  try{
    const response = await fetch(urlEmpleados, {
      method: 'POST',

      headers:{
        'Content-Type':'application/json'
      }
    });
    if(response.ok){
      const jsonResponse = await response.json()
      const{correo, apellido_nombre, nombre_cargo} = jsonResponse
    }
  }
}
*/

onMounted(async ()=> {
 await getEmpleados()
})
</script>
<template>
  <header>
    <h1 style="text-align: center;">Empleados Cubit</h1>
  </header>
  <div class="grid">
    <div class="col-12">
      <div class="mb-3">
      <DataTable :value="listaempleados">
        <Column field="apellido_nombre" header="Apellido y Nombre"></Column>
        <Column field="correo" header="Email"></Column>
        <Column field="nombre_cargo" header="Cargo"></Column>       
      </DataTable>
      </div>      
    </div>
  </div>
  <div class="col-12 p-3">
        <p>En desarrollo</p>  
          <Button class ="m-3" id="nuevo_empleado" label="Nuevo Empleado" outlined/>
          <Button class ="m-3" id="mod_empleado" label="Modificar Empleado" severity="secondary" outlined />
          <Button class ="m-3" id="del_empleado" label="Eliminar Empleado" severity="success" outlined />
  </div>
</template>
