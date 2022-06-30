import { createAction } from "@reduxjs/toolkit";

export const changeRepositoryType = "changeRepository";

export const changeRepositoryAction = createAction<string>(changeRepositoryType);