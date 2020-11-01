<template>
  <div class="container">
    <div class="form-element-group">
      <input id="spent-filter" type="text" class="form-element" :placeholder="$t('menu.filter')"
             v-model="filter" v-on:focusout="$store.dispatch('filterExpenditures', filter)">
      <span class="form-element-extra"><i class="fa fa-filter"></i></span>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'ExpenditureFilterBar',
    data: function () {
      return {
        filter: '[{ "name": "Amount", "value": 10 }]'
      }
    }
  }
</script>
