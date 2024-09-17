# NotificationService


This repository contains a notification service designed to handle and send notifications through multiple channels. The system is composed of three microservices for email, SMS, and push notifications, all of which are orchestrated using RabbitMQ for messaging.

## Overview

The Notification Service is built to support sending notifications via:

- Email: Handles sending of transactional and promotional emails.
- SMS: Manages sending of text messages to mobile devices.
- Push Notifications: Facilitates sending of notifications to mobile and web applications.

## Architecture

The architecture is built around a message-driven microservices approach:

- Notification Service API: Central API for receiving notification requests and dispatching them to appropriate channels.
- Email Microservice: Processes email notifications.
- SMS Microservice: Manages SMS notifications.
- Push Notification Microservice: Sends push notifications to users.

## RabbitMQ
RabbitMQ is used as the messaging broker to facilitate communication between the Notification Service API and the microservices. It ensures reliable and scalable message delivery.