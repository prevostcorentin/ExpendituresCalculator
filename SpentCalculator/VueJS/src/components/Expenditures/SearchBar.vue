<template>
  <div class="container">
    <div class="form-element-group">
      <input id="spent-filter" type="text" class="form-element" :placeholder="$t('menu.filter')"
             v-model="filterContent" v-on:focusout="leaveBar">
      <span class="form-element-extra"><i class="fa fa-filter"></i></span>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'SearchBar',
    data: function () {
      return {
        filterContent: '[{ "name": "Amount", "value": 10 }]'
      }
    },
    methods: {
      leaveBar () {
        this.$store.commit('updateExpenditures', this.filterContent)
      }
    }
  }
</script>
