#!/usr/bin/env bash

nuget-license --input Innago.Shared.UnitTesting.slnx \
  --include-shared-projects \
  --output jsonpretty \
  --allowed-license-types ./.github/actions/check-licenses-action/allowed-licenses.json \
  --ignored-packages ./.github/actions/check-licenses-action/ignored-packages.json \
  --error-only | tee l.json | jq '.[] | select(.ValidationErrors != null)'