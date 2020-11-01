<template>
  <tr class="expenditure-item">
    <td>{{ expenditure.name }}</td>
    <td>{{ expenditure.dateTime }}</td>
    <td>{{ expenditure.amount }}</td>
    <td><a href=""><i class="fa fa-pencil"></i></a></td>
    <td><a href=""><i class="fa fa-trash"></i></a></td>
  </tr>
</template>

<script>
  export default {
    name: 'ExpenditureItem',
    props: ['expenditure']
  }
</script>

<style scoped>
  tr :hover
  {
    background-color: lightblue;
  }
</style>
