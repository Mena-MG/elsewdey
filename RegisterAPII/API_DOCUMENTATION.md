# School Management System API Documentation

## Overview
This document outlines all the API endpoints for the School Management System, including the newly implemented features for Notes Management, Reports System, Notifications, and Staff Management.

## Base URL
```
https://your-api-domain.com/api
```

## Authentication
Most endpoints require JWT authentication. Include the token in the Authorization header:
```
Authorization: Bearer <your-jwt-token>
```

---

## 📝 Notes Management API

### Create Note
**POST** `/api/notes`

Creates a new note for a student.

**Request Body:**
```json
{
  "content": "Student showed excellent behavior in class today",
  "type": "Good",
  "studentProfileId": 1
}
```

**Response:**
```json
{
  "id": 1,
  "content": "Student showed excellent behavior in class today",
  "type": "Good",
  "studentProfileId": 1,
  "studentName": "John Doe",
  "createdByAccountId": 5,
  "createdByName": "Teacher Smith",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": null,
  "isActive": true
}
```

### Update Note
**PUT** `/api/notes/{id}`

Updates an existing note (only by the creator).

**Request Body:**
```json
{
  "content": "Updated note content",
  "type": "Good"
}
```

### Delete Note
**DELETE** `/api/notes/{id}`

Soft deletes a note (only by the creator).

### Get Note by ID
**GET** `/api/notes/{id}`

Retrieves a specific note by ID.

### Get Notes by Student
**GET** `/api/notes/student/{studentId}`

Retrieves all notes for a specific student.

### Get Notes by Type
**GET** `/api/notes/student/{studentId}/type/{type}`

Retrieves notes of a specific type ("Good" or "Bad") for a student.

### Get My Notes
**GET** `/api/notes/my-notes`

Retrieves all notes created by the authenticated user.

---

## 📋 Reports System API

### Create Report
**POST** `/api/reports`

Creates a new report for a student.

**Request Body:**
```json
{
  "title": "Behavioral Issue Report",
  "content": "Student has been consistently disruptive during class sessions...",
  "type": "Behavioral",
  "studentProfileId": 1
}
```

**Response:**
```json
{
  "id": 1,
  "title": "Behavioral Issue Report",
  "content": "Student has been consistently disruptive during class sessions...",
  "type": "Behavioral",
  "studentProfileId": 1,
  "studentName": "John Doe",
  "createdByAccountId": 5,
  "createdByName": "Teacher Smith",
  "reviewedByAccountId": null,
  "reviewedByName": null,
  "status": "Pending",
  "adminComments": null,
  "createdAt": "2024-01-15T10:30:00Z",
  "reviewedAt": null,
  "isActive": true
}
```

### Review Report
**PUT** `/api/reports/{id}/review`

Reviews a report (Admin only).

**Request Body:**
```json
{
  "status": "Approved",
  "adminComments": "Report approved. Parent will be notified."
}
```

### Get Report by ID
**GET** `/api/reports/{id}`

Retrieves a specific report by ID.

### Get Reports by Student
**GET** `/api/reports/student/{studentId}`

Retrieves all reports for a specific student.

### Get Pending Reports
**GET** `/api/reports/pending`

Retrieves all pending reports (Admin only).

### Get My Reports
**GET** `/api/reports/my-reports`

Retrieves all reports created by the authenticated user.

### Get Reports by Status
**GET** `/api/reports/status/{status}`

Retrieves reports by status ("Pending", "Approved", "Rejected").

---

## 🔔 Notifications API

### Create Notification
**POST** `/api/notifications`

Creates a new notification.

**Request Body:**
```json
{
  "title": "New Assignment",
  "message": "A new assignment has been posted for your class",
  "type": "General",
  "toAccountId": 10,
  "relatedEntityId": null,
  "relatedEntityType": null
}
```

### Mark Notification as Read
**PUT** `/api/notifications/{id}/mark-read`

Marks a notification as read.

### Get My Notifications
**GET** `/api/notifications/my-notifications`

Retrieves all notifications for the authenticated user.

### Get Unread Notifications
**GET** `/api/notifications/unread`

Retrieves unread notifications for the authenticated user.

### Get Unread Count
**GET** `/api/notifications/unread-count`

Returns the count of unread notifications.

**Response:**
```json
{
  "count": 5
}
```

---

## 👨‍💼 Staff Management API (IT Role Only)

### Create Staff
**POST** `/api/staffmanagement`

Creates a new staff member.

**Request Body:**
```json
{
  "fullName": "Jane Doe",
  "email": "jane.doe@school.com",
  "nationalID": "1234567890123",
  "roleId": 6,
  "specialization": "Mathematics"
}
```

### Update Staff
**PUT** `/api/staffmanagement/{id}`

Updates staff member information.

**Request Body:**
```json
{
  "fullName": "Jane Doe",
  "email": "jane.doe@school.com",
  "roleId": 6,
  "specialization": "Mathematics",
  "isActive": true
}
```

### Delete Staff
**DELETE** `/api/staffmanagement/{id}`

Deactivates a staff member.

### Get Staff by ID
**GET** `/api/staffmanagement/{id}`

Retrieves a specific staff member.

### Get All Staff
**GET** `/api/staffmanagement`

Retrieves all staff members.

### Get Staff by Role
**GET** `/api/staffmanagement/role/{roleId}`

Retrieves staff members by role.

### Activate Staff
**PUT** `/api/staffmanagement/{id}/activate`

Activates a staff member.

### Deactivate Staff
**PUT** `/api/staffmanagement/{id}/deactivate`

Deactivates a staff member.

---

## 👤 Student Profile API (Existing)

### Create Student Profile
**POST** `/api/studentprofile/create`

### Get Student Profile
**GET** `/api/studentprofile/{id}`

### Update Notes
**PUT** `/api/studentprofile/{id}/update-notes`

---

## 🔐 Authentication API (Existing)

### Check User
**POST** `/api/auth/check`

### Login
**POST** `/api/auth/login`

---

## 📊 Grades API (Existing)

### Get All Grades
**GET** `/api/grade`

---

## Error Responses

All endpoints may return the following error responses:

### 400 Bad Request
```json
{
  "message": "Invalid request data"
}
```

### 401 Unauthorized
```json
{
  "message": "Authentication required"
}
```

### 403 Forbidden
```json
{
  "message": "You don't have permission to access this resource"
}
```

### 404 Not Found
```json
{
  "message": "Resource not found"
}
```

### 500 Internal Server Error
```json
{
  "message": "An unexpected error occurred"
}
```

---

## Role-Based Access Control

### Roles
1. **SuperAdmin** - Full system access
2. **Admin** - Administrative functions, report review
3. **Student** - Limited access to own profile
4. **Specialist** - Can create notes and reports
5. **IT** - Staff management only
6. **Teacher** - Can create notes and reports
7. **Engineer** - Technical support
8. **Parent** - View child's information

### Access Matrix

| Feature | SuperAdmin | Admin | Teacher | Specialist | Student | Parent | IT | Engineer |
|---------|------------|-------|---------|------------|---------|--------|----|----------|
| Create Notes | ✅ | ✅ | ✅ | ✅ | ❌ | ❌ | ❌ | ❌ |
| View Notes | ✅ | ✅ | ✅ | ✅ | Own Only | Child Only | ❌ | ❌ |
| Create Reports | ✅ | ✅ | ✅ | ✅ | ❌ | ❌ | ❌ | ❌ |
| Review Reports | ✅ | ✅ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ |
| Staff Management | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ |
| Notifications | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |

---

## Database Schema Updates

To implement the new features, run the SQL script in `DATABASE_MIGRATION_SCRIPT.sql` to create the following new tables:

1. **Notes** - Stores student notes
2. **Reports** - Stores student reports
3. **Notifications** - Stores system notifications

---

## Implementation Status

### ✅ Completed Features
- Database models and relationships
- Service layer implementations
- API controllers and endpoints
- Data Transfer Objects (DTOs)
- Basic error handling
- Role-based structure

### ⏳ Pending Tasks
1. **JWT Authentication Integration** - Currently using placeholder user IDs
2. **Role-based Authorization** - Add proper role checks to controllers
3. **Notification Integration** - Connect note/report creation with notifications
4. **Email Notifications** - Send emails for important notifications
5. **Input Validation** - Add comprehensive validation attributes
6. **Unit Tests** - Create comprehensive test coverage
7. **API Rate Limiting** - Implement rate limiting for security
8. **Logging** - Add structured logging throughout the application

### 🔧 Recommended Next Steps
1. Implement proper JWT token extraction in controllers
2. Add role-based authorization attributes to endpoints
3. Create notification background service
4. Add comprehensive input validation
5. Implement email service integration
6. Add API documentation with Swagger
7. Create integration tests