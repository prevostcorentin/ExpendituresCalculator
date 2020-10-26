'use strict'

const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  SERVER_NAME: '"localhost"',
  SERVER_PORT: '"44320"',
  PROTOCOL: '"https"'
})
